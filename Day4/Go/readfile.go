package main

import (
	"bufio"
	"log"
	"os"
)

// ReadFile reads a file line by line and returns a slice of strings
func ReadFile(filePath string) []string {
	// File Content Slice
	var fileLines []string

	// Open the input file
	file, err := os.Open(filePath)
	if err != nil {
		log.Fatal(err)
	}
	defer file.Close()

	// Set up scanner to read file line by line
	scanner := bufio.NewScanner(file)

	// Read each line and append to slice
	for scanner.Scan() {
		fileLines = append(fileLines, scanner.Text())
	}
	return fileLines
}
