package main

import (
	"fmt"
	"strings"
)

func main() {
	// Define the file path
	filePath := "../input.txt"

	// Read lines from the file
	lines := strings.Join(ReadFile(filePath), "\n")

	var partOneJoltage int64
	var partTwoJoltage int64

	// Part One
	for _, line := range strings.Split(lines, "\n") {
		joltage := NewJoltage(line, 2)
		partOneJoltage += joltage.highestJoltage
	}

	// Part Two
	for _, line := range strings.Split(lines, "\n") {
		joltage := NewJoltage(line, 12)
		partTwoJoltage += joltage.highestJoltage
	}

	fmt.Println("Part One Joltage:", partOneJoltage)
	fmt.Println("Part Two Joltage:", partTwoJoltage)
}
