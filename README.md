# AUD-Equations Group Work

*Group - Aigner, Wimmer, Sturm, Mayr and Aspöck*

This repository is part of a school group work on matrix calculation. Given a result matrix C the goal of the assignment is to calculate the two matrices A and B which when multiplied result in the matrix C. This problem is simplified by some constant numbers in the matrices.

## Repository Structure

* `src` - Directory containing the source code of the project
  * `C#` - Directory containing final C# source code (frontend + backend)
  * `Go` - Directory containing [Go](https://go.dev/) source code as our first intention was to program the project in Go
* `examples` - Directory containing example matrices in .csv format
* [`Angabe`](3q4t10n5.pdf) - Specification and instructions for this school assignment
* [`Todo`](TODO.md) - List for current tasks of the team

## Usage

This project consists of two parts:
* Console application - In the console you will need to input a path containing a csv file with the result matrix C you want to use for calculation. The program then outputs the matrices A and B.
* WPF application - The frontend is not in a functional state and should not be used by now - please refer to the console application for a functional experience. 
