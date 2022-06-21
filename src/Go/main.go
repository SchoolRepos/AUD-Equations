package main

import (
	"fmt"
	"io/ioutil"
	"log"
	"os"
	"strconv"
	"strings"
)

func main() {
	fileName := "input.csv"
	if len(os.Args) > 1 {
		fileName = os.Args[1]
	}
	C, err := ReadCSV(fileName)
	if err != nil {
		log.Fatal("Error reading CSV:", err)
	}

	A, B := CalculateAAndBXByX(C)
	fmt.Println("A:")
	printMatrix(A)
	fmt.Println()
	fmt.Println("B:")
	printMatrix(B)
}

func printMatrix(matrix [][]float64) {
	for _, row := range matrix {
		fmt.Print("[")
		for idx, col := range row {
			fmt.Printf("%.2f", col)
			if idx != len(row)-1 {
				fmt.Print(" ")
			}
		}
		fmt.Println("]")
	}
}

func CalculateAAndB3By3(C [][]float64) (A, B [][]float64) {
	A = [][]float64{{1, 0, 0}, {0, 1, 0}, {0, 0, 1}}
	B = [][]float64{{0, 0, 0}, {0, 0, 0}, {0, 0, 0}}

	B[0][0] = C[0][0]
	B[0][1] = C[0][1]
	B[0][2] = C[0][2]

	A[1][0] = C[1][0] / B[0][0]
	B[1][1] = C[1][1] - A[1][0]*B[0][1]
	B[1][2] = C[1][2] - A[1][0]*B[0][2]

	A[2][0] = C[2][0] / B[0][0]
	A[2][1] = (C[2][1] - A[2][0]*B[0][1]) / B[1][1]
	B[2][2] = C[2][2] - A[2][0]*B[0][2] - A[2][1]*B[1][2]

	return
}

func CalculateAAndBXByX(C [][]float64) (A, B [][]float64) {
	A = make([][]float64, len(C))
	B = make([][]float64, len(C))
	for i := range A {
		A[i] = make([]float64, len(C))
		B[i] = make([]float64, len(C))
	}

	// Fill ones
	for i := range C {
		A[i][i] = 1
	}

	// Fill first B row
	for i := range C {
		B[0][i] = C[0][i]
	}

	// For each row
	for i := range C {
		A[i][0] = C[i][0] / B[0][0]

		// Fill A of row
		for j := 0; j < i; j++ {
			var sum float64
			for k := 0; k < j; k++ {
				sum += A[i][k] * B[k][j]
			}
			A[i][j] = (C[i][j] - sum) / B[j][j]
		}

		// Fill B of row
		for j := i; j < len(C[0]); j++ {
			var number float64
			for k := 0; k < i; k++ {
				number += A[i][k] * B[k][j]
			}
			B[i][j] = C[i][j] - number
		}
	}

	return
}

func ReadCSV(path string) ([][]float64, error) {
	bytes, err := ioutil.ReadFile(path)
	if err != nil {
		return [][]float64{}, err
	}
	lines := strings.Split(string(bytes), "\n")
	matrix := [][]float64{}
	for _, line := range lines {
		if strings.TrimSpace(line) == "" {
			continue
		}
		row := []float64{}
		parts := strings.Split(line, ";")
		for _, part := range parts {
			if strings.TrimSpace(part) == "" {
				continue
			}
			num, err := strconv.ParseFloat(strings.ReplaceAll(part, ",", "."), 64)
			if err != nil {
				return matrix, err
			}
			row = append(row, num)
		}
		matrix = append(matrix, row)
	}

	return matrix, nil
}
