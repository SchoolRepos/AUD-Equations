package main

import (
	"reflect"
	"testing"
)

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
	haveA, haveB, err := CalculateAAndB3By3(C)
	if err != nil {
		t.Errorf("CalculateAAndB3By3(%v) returned error: %v", C, err)
	}
	if !reflect.DeepEqual(haveA, wantA) {
		t.Errorf("CalculateAAndB3By3(%v) returned A %v, want %v", C, haveA, wantA)
	}
	if !reflect.DeepEqual(haveB, wantB) {
		t.Errorf("CalculateAAndB3By3(%v) returned B %v, want %v", C, haveB, wantB)
	}
}
