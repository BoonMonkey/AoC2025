package main

import (
	"strings"
)

func main() {
	// Define the file path
	filePath := "../input.txt"

	// Read lines from the file
	lines := strings.Join(ReadFile(filePath), "\n	")

	inputs := strings.Split(lines, ",")
}
