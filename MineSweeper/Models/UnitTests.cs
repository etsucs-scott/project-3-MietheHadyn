using MineSweeper.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static System.Reflection.Metadata.BlobBuilder;

namespace MineSweeper.Models
{

    public class BoardTests
    {
        //xUnit test for seedPlaceBombs method: check if bombs are placed correctly based on seed and bomb count
        [Fact]
        public void SeedPlaceBombs_CorrectNumBombs()
        {
            //arrange
            var board = new Board(12, 12, 25);
            //act
            board.seedPlaceBombs(12345, 12, 12, board.Bombcount);
            int bombCount = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (board.board[i, j] == Board.bomb)
                    {
                        bombCount++;
                    }
                }
            }
            //assert
            Assert.Equal(25, bombCount);
        }

        public void SeedBombRecreations()
        {
            //arrange
            var board1 = new Board(12, 12, 25);
            var board2 = new Board(12, 12, 25);
            //act
            board1.seedPlaceBombs(12345, 12, 12, board1.Bombcount);
            board2.seedPlaceBombs(12345, 12, 12, board2.Bombcount);
            //assert
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    Assert.Equal(board1.board[i, j], board2.board[i, j]);
                }
            }
        }
        
    }

    public class  FlagTests
    {
        public void Flag()
        {
            //arrange
            var board = new Board(12, 12, 25);
            var cell = board.board[8, 8];
            var flagger = new Flag(); //flag instancer
            List<(int, int)> flagLocations = new List<(int, int)>();
            //act
            cell = Board.flag;
            if (!flagLocations.Contains((8, 8)))
                flagLocations.Add((8, 8));
            //assert
            Assert.Equal(Board.flag, cell);
        }

        public void FlagBomb()
        {
            //arrange
            var board = new Board(12, 12, 25);
            var cell = board.board[8, 8];
            var flagger = new Flag(); //flag instancer
            List<(int, int)> flagLocations = new List<(int, int)>();
            //act
            cell = Board.flag;
            if (!flagLocations.Contains((8, 8)))
                flagLocations.Add((8, 8)); //flag bomb
            if (board.bombLocations.Contains((8, 8)))
            {
                board.board[8, 8] = Board.bomb;
            }
            else
            {
                board.board[8, 8] = null;
            }
            flagLocations.Remove((8, 8));
            //assert
            Assert.Equal(Board.bomb, cell);

        }
    }

    //xUnit test for actReveal method: reveal empty cell, reveal bomb cell, reveal already revealed cell
    //Seed for all tests is 12345 with a board size of 12x12 and 25 bombs

    public class RevealTests
    {
        //Revealing bombs
        [Fact]
        public void RevealBomb()
        {
            //arrange
            var board = new Board(12, 12, 25);
            board.seedPlaceBombs(12345, 12, 12, board.Bombcount);
            var revealer = new Reveal(); //reveal instancer
            //act 
            bool bombFound = revealer.actReveal(8, 4, board);
            //assert
            Assert.True(bombFound);

        }

        public void RevealNONBomb()
        {
            //arrange
            var board = new Board(12, 12, 25);
            board.seedPlaceBombs(12345, 12, 12, board.Bombcount);
            var revealer = new Reveal(); //reveal instancer
            //act
            bool bombFound = revealer.actReveal(2, 1, board);
            //assert
            Assert.False(bombFound);
        }

        public void RevealNearbyBombCnt()
        {
           //arrange
            var board = new Board(12, 12, 25);
            board.seedPlaceBombs(12345, 12, 12, board.Bombcount);
            var revealer = new Reveal(); //reveal instancer
            //act
            bool bombFound = revealer.actReveal(10, 6, board);
            //assert
            Assert.Equal("2", board.board[10, 6]);
        }


    }

    //xUnit tests: CalcElapsedTime, loss return score 00000
    public class HighScoresTests
    {
        [Fact]
        public void ScoreCalc_Win_ReturnsCorrectScore()
        {
            // Arrange
            DateTime startTime = new DateTime(2024, 1, 1, 0, 0, 0);
            DateTime endTime = new DateTime(2024, 1, 1, 0, 2, 30); //150 seconds later
            bool win = true;
            // Act
            int score = HighScores.ScoreCalc(startTime, endTime, win);
            // Assert
            Assert.Equal(150, score);
        }


        [Fact]
        public void ScoreCalc_Loss_ReturnsZero()
        {
            // Arrange
            DateTime startTime = new DateTime(2024, 1, 1, 0, 0, 0);
            DateTime endTime = new DateTime(2024, 1, 1, 0, 2, 30);
            bool win = false;
            //Act
            int score = HighScores.ScoreCalc(startTime, endTime, win);
            //Assert
            Assert.Equal(00000, score);
        }
    }

    public class WinTest
    {
        
        [Fact]
        public void WinCondition_AllNonBombsRevealed_ReturnsWin()
        {
            //arrange
            var board = new Board(12, 12, 25);
            board.seedPlaceBombs(12345, 12, 12, board.Bombcount);

            //reveal all non-Bombs; leave bombs unrevealed
            int rows = board.board.GetLength(0);
            int cols = board.board.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!board.bombLocations.Contains((i, j)))
                    {
                        board.board[i, j] = Board.emptyRevealed; //revealed cell
                    }
                    else
                    {
                        board.board[i, j] = Board.bomb; //ensure bomb remains
                    }
                }
            }
        }
    }
}
