class Dial:
    def __init__(self, size, position):
        self.size = size
        self.position = position
        self.stepValue = 1
        self.timesReachedZero = 0

    def turn(self, steps, direction):
        self.step_value_calc(direction)
        self.position += steps * self.stepValue
        self.position = ((self.position % self.size) + self.size) % self.size
        self.check_zero()

    def turn_check_all_steps(self, steps, direction):
        self.step_value_calc(direction)
        for _ in range(steps):
          self.position += self.stepValue
          self.position = ((self.position % self.size) + self.size) % self.size
          self.check_zero()

    def step_value_calc(self, direction):
        if direction == 'R':
            self.stepValue = 1
        elif direction == 'L':
            self.stepValue = -1
    
    def check_zero(self):
        if self.position == 0:
            self.timesReachedZero += 1