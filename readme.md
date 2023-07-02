# Bowling Game

A console application that simulates a game of bowling. It allows players to roll a virtual bowling ball and keeps track of the score based on the rules of bowling.

## Design Choices

### Frame Class

The design includes a Frame class to represent each frame in the game. The Frame class contains an array of rolls, which allows for easy tracking of the number of pins knocked down in each roll. The class also includes methods to determine if a frame is a strike or a spare, as well as calculating the frame score.

### BowlingGame Class

The BowlingGame class is responsible for managing the overall game logic. It maintains a list of frames and keeps track of the current roll, current frame, and total score. It provides methods playing the game and calculating the score.

### Separation of Concerns

The design follows the principle of separation of concerns, where the logic for scoring and frame calculations is kept separate from the user interface. This allows for easier maintenance and extensibility of the code. The BowlingGame class handles the game mechanics, while the user interface is implemented in the Program class, which interacts with the user through the console.

### Random Pin Knockdown

The application uses the Random class to simulate the knocking down of pins. The Roll method generates a random number between 0 and 10 to determine the number of pins knocked down in each roll. This adds an element of randomness to the game, simulating real-life bowling.

## Usage

To play the Bowling Game, simply run the console application. The game will prompt you to press any key to start the game and roll the ball. Each roll will display the frame number, roll number, number of pins knocked down, and the total score. Press any key to roll again.
