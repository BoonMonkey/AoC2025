# Import input file
from dial import Dial

with open('../input.txt', 'r') as file:
    lines = file.read().split("\n")

def __main__():
    # Initialize part one dial
    part_one = Dial(100, 50)
    for line in lines:
        direction = line[0]
        steps = int(line[1:])
        part_one.turn(steps, direction)
    print("Part 1 - Times reached zero:", part_one.timesReachedZero )

    # Initialize part two dial
    part_two = Dial(100, 50)
    for line in lines:
      direction = line[0]
      steps = int(line[1:])
      part_two.turn_check_all_steps(steps, direction)
    print("Part 2 - Times reached zero:", part_two.timesReachedZero )

if __name__ == "__main__":
    __main__()