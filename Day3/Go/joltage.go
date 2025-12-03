package main

import (
	"strconv"
	"strings"
)

type Joltage struct {
	bank           string
	highestJoltage int64
	bankList       []string
}

func NewJoltage(bank string, batteryCount int) *Joltage {
	j := &Joltage{
		bank:           bank,
		highestJoltage: 0,
		bankList:       strings.Split(bank, ""),
	}
	j.getHighestJoltage(batteryCount)
	return j
}

func (j *Joltage) getHighestJoltage(batteryCount int) {
	bankList := j.bankList
	enabledBatteries := []string{}
	disableCounter := len(bankList) - batteryCount

	for _, battery := range bankList {
		for disableCounter > 0 && len(enabledBatteries) > 0 && battery > enabledBatteries[len(enabledBatteries)-1] {
			enabledBatteries = enabledBatteries[:len(enabledBatteries)-1]
			disableCounter--
		}
		enabledBatteries = append(enabledBatteries, battery)
	}

	for len(enabledBatteries) > batteryCount {
		enabledBatteries = enabledBatteries[:len(enabledBatteries)-1]
	}

	jointHighestJoltage := strings.Join(enabledBatteries, "")
	result, _ := strconv.ParseInt(jointHighestJoltage, 10, 64)
	j.highestJoltage = result
}
