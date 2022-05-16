package main

import (
	"reflect"
	"testing"
)

func TestCalculateAAndB(t *testing.T) {
	type args struct {
		C [][]int
	}
	tests := []struct {
		name    string
		args    args
		wantA   [][]int
		wantB   [][]int
		wantErr bool
	}{
		// TODO: Add test cases.
	}
	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			gotA, gotB, err := CalculateAAndB(tt.args.C)
			if (err != nil) != tt.wantErr {
				t.Errorf("CalculateAAndB() error = %v, wantErr %v", err, tt.wantErr)
				return
			}
			if !reflect.DeepEqual(gotA, tt.wantA) {
				t.Errorf("CalculateAAndB() gotA = %v, want %v", gotA, tt.wantA)
			}
			if !reflect.DeepEqual(gotB, tt.wantB) {
				t.Errorf("CalculateAAndB() gotB = %v, want %v", gotB, tt.wantB)
			}
		})
	}
}
