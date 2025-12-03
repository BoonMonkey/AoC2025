package main

import (
	"fmt"
	"strconv"
	"strings"
)

func main() {
	// Define the file path
	filePath := "../input.txt"

	// Read lines from the file
	lines := strings.Join(ReadFile(filePath), "\n	")

	inputs := strings.Split(lines, ",")

	var invalidIdValue int64
	for _, input := range inputs {
		startId, err := strconv.ParseInt(strings.Split(input, "-")[0], 10, 64)
		if err != nil {
			fmt.Println("Error converting startId:", err)
		}

		endId, err := strconv.ParseInt(strings.Split(input, "-")[1], 10, 64)
		if err != nil {
			fmt.Println("Error converting endId:", err)
		}

		idCheck := NewIdCheck(startId, endId)
		invalidIdValue += idCheck.sumOfInvalidIds
	}
	fmt.Println("Sum of Invalid IDs:", invalidIdValue)
}
