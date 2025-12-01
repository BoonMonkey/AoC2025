package main

import (
	"fmt"
	"strconv"
)

func main() {
	// Define the file path
	filePath := "../input.txt"

	// Read lines from the file
	lines := ReadFile(filePath)

	// Part One Solution
	var partOne = NewDial(100, 50)
	for _, line := range lines {
		direction := string(line[0])
		steps, err := strconv.Atoi(line[1:])
		if err != nil {
			fmt.Println("Error converting steps:", err)
		}
		partOne.Turn(steps, direction)
	}
	fmt.Println("Part One - Times Reached Zero:", partOne.TimesReachedZero)

	// Part Two Solution
	var partTwo = NewDial(100, 50)
	for _, line := range lines {
		direction := string(line[0])
		steps, err := strconv.Atoi(line[1:])
		if err != nil {
			fmt.Println("Error converting steps:", err)
		}
		partTwo.TurnCountAllZeros(steps, direction)
	}
	fmt.Println("Part Two - Times Reached Zero:", partTwo.TimesReachedZero)
}
