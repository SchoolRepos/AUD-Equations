package main

import (
	"math"
	"testing"
)

const float64EqualityThreshold = 1e-9

func almostEqual(a, b float64) bool {
	return math.Abs(a-b) <= float64EqualityThreshold
}

func TestCalculateAAndB3By3(t *testing.T) {
	C := [][]float64{
		{2, 7, 1},
		{3, -2, 8},
		{1, 5, 3},
	}
	wantA := [][]float64{
		{1, 0, 0},
		{1.5, 1, 0},
		{0.5, -0.12, 1},
	}
	wantB := [][]float64{
		{2, 7, 1},
		{0, -12.5, 6.5},
		{0, 0, 3.28},
	}
	haveA, haveB := CalculateAAndB3By3(C)
	if !floatSlicesEqual(haveA, wantA) {
		t.Errorf("CalculateAAndB3By3(%v) returned A %v, want %v", C, haveA, wantA)
	}
	if !floatSlicesEqual(haveB, wantB) {
		t.Errorf("CalculateAAndB3By3(%v) returned B %v, want %v", C, haveB, wantB)
	}
}

func TestCalculateAAndBXByX(t *testing.T) {
	type testCase struct {
		C     [][]float64
		WantA [][]float64
		WantB [][]float64
	}
	testCases := []testCase{
		{
			C: [][]float64{
				{2, 7, 1},
				{3, -2, 8},
				{1, 5, 3},
			},
			WantA: [][]float64{
				{1, 0, 0},
				{1.5, 1, 0},
				{0.5, -0.12, 1},
			},
			WantB: [][]float64{
				{2, 7, 1},
				{0, -12.5, 6.5},
				{0, 0, 3.28},
			},
		},
	}
	for _, currentTestCase := range testCases {
		haveA, haveB := CalculateAAndBXByX(currentTestCase.C)
		if !floatSlicesEqual(haveA, currentTestCase.WantA) {
			t.Errorf("CalculateAAndB3By3(%v) returned A %v, want %v", currentTestCase.C, haveA, currentTestCase.WantA)
		}
		if !floatSlicesEqual(haveB, currentTestCase.WantB) {
			t.Errorf("CalculateAAndB3By3(%v) returned B %v, want %v", currentTestCase.C, haveB, currentTestCase.WantB)
		}
	}
}

func floatSlicesEqual(A, B [][]float64) bool {
	if len(A) != len(B) {
		return false
	}
	for rowIdx := range A {
		if len(A[rowIdx]) != len(B[rowIdx]) {
			return false
		}
		for colIdx := range A[rowIdx] {
			if !almostEqual(A[rowIdx][colIdx], B[rowIdx][colIdx]) {
				return false
			}
		}
	}
	return true
}
