package main

type paperPile struct {
	x int
	y int
}

func NewPaperPile(startX int, startY int) *paperPile {
	pp := &paperPile{
		x: startX,
		y: startY,
	}
	return pp
}

func (pp *paperPile) addStack() {
	pp.y++
}

func (pp *paperPile) AddRoll(position int) {
	pp.x += position
}

type paperGrid struct {
	gridLocations map[[2]int]string
	offsetCoords  [][2]int
}
