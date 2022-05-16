package main

import "errors"

func main() {

}

func CalculateAAndB(C [][]int) (A, B [][]int, err error) {
	// check for square matrix
	if len(C) != len(C[0]) {
		err = errors.New("C is not a square matrix")
		return
	}

	return
}
