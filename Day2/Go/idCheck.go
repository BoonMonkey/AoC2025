package main

import (
	"strconv"
)

type idCheck struct {
	startId         int64
	endId           int64
	idsToCheck      []int64
	sumOfInvalidIds int64
	invalidIds      []int64
}

func NewIdCheck(startId int64, endId int64) *idCheck {
	ic := &idCheck{
		startId: startId,
		endId:   endId,
	}
	ic.idsToCheck = ic.getIdsToCheck(startId, endId)
	ic.invalidIds = ic.getInvalidIds(ic.idsToCheck)
	ic.sumOfInvalidIds = ic.getSumOfInvalidIds(ic.invalidIds)
	return ic
}

func (ic *idCheck) getIdsToCheck(startId int64, endId int64) []int64 {
	var idRange []int64
	for i := startId; i <= endId; i++ {
		idRange = append(idRange, i)
	}
	return idRange
}

func (ic *idCheck) getInvalidIds(idRange []int64) []int64 {
	for _, id := range idRange {
		idStr := strconv.FormatInt(id, 10)
		idLength := len(idStr)

		for i := 1; i <= idLength/2; i++ {
			if idLength%i != 0 {
				continue
			}

			pattern := idStr[:i]
			var builtStr string
			for j := 0; j < idLength/i; j++ {
				builtStr += pattern
			}
			if builtStr == idStr {
				ic.invalidIds = append(ic.invalidIds, id)
				break
			}
		}
	}
	return ic.invalidIds
}

func (ic *idCheck) getSumOfInvalidIds(invalidIds []int64) int64 {
	var sum int64
	for _, id := range invalidIds {
		sum += id
	}
	return sum
}
