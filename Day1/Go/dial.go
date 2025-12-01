package main

// Dial represents a circular dial with a specific size and position
type dial struct {
	Size             int
	Position         int
	TimesReachedZero int
	StepValue        int
}

// NewDial creates a new Dial instance with the given size and starting position
func NewDial(size int, startPosition int) *dial {
	return &dial{
		Size:     size,
		Position: startPosition,
	}
}

func (d *dial) Turn(steps int, direction string) {
	// Determine step value based on direction
	d.StepValueCalc(direction)

	// Update position with wrap-around logic
	d.Position += steps * d.StepValue
	d.Position = ((d.Position + d.Size) + d.Size) % d.Size

	// Check if position is zero
	d.CheckZero()
}

func (d *dial) TurnCountAllZeros(steps int, direction string) {
	// Determine step value based on direction
	d.StepValueCalc(direction)

	// Update position step by step to count all zeros
	for i := 0; i < steps; i++ {
		d.Position += d.StepValue
		d.Position = ((d.Position + d.Size) + d.Size) % d.Size
		d.CheckZero()
	}
}

func (d *dial) StepValueCalc(direction string) {
	if direction == "R" {
		d.StepValue = 1
	} else if direction == "L" {
		d.StepValue = -1
	}
}

func (d *dial) CheckZero() {
	if d.Position == 0 {
		d.TimesReachedZero++
	}
}
