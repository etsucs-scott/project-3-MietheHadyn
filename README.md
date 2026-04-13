# CSCI 1260 — Project

## Project Notes

### Build and run
```bash
dotnet build
dotnet run --project MineSweeper.App
```

### Board Size, Input, Seeds
You choose from 3 board sizes: 
- 8x8, with 10 bombs
- 12x12, with 25 bombs
- 16x16, with 40 bombs

The Game will ask you to input your action, the x value, and the y value in three spearate prompts.
Entering "r" will reveal the cell at the (x,y) of your choosing, while entering "f" will place/remove a flag there.

Seeds are used to deterministically place the bombs on the board, so said locations can be replicated if the player wants, also allowing them to retry a board after they've failed.

### High Scores and Files
High scores are calculated by the time it takes you to finish a game of MineSweeper. They are stored in a file in the solution's bin folder.

### Board Symbols
Bombs (hidden): "#" (revealed, exploded): "X"
Flags: "F"
Hidden cells: "#"
Empty cells, with no nearby bombs: "."
Empty cells, with nearby bombs: will show the number of adjacent bombs: "1-8"

### Unit tests
To run all tests in the repo:
```bash
dotnet test
```
