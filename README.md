![Logo of the project](https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Tic_tac_toe.svg/400px-Tic_tac_toe.svg.png)

# Tic Tac Toe
> A popular 3 x 3 board game where two players take turns marking a space on the board. The first player to place three of their marks in a 
> horizontal, vertical, or diagonal row wins!

The purpose of this project is to practice SOLID principles, writing good unit tests, and taking an iterative approach to building a simple Tic Tac Toe game.
Also, in this game the user will be playing against an *impossible AI*, which is based on the **Minimax Algorithm**. 

# Table of Contents
- [Tic Tac Toe](#tic-tac-toe)
  * [Playthrough](#playthrough)
  * [Design](#design)
    + [Flowchart](#flowchart)
    + [Class Diagram](#class-diagram)
    + [Iteration](#iteration)
  * [Features](#features)
  * [Challenges](#challenges)
  * [Solutions](#solutions)
    + [Solution to challenge #1](#solution1)
    + [Solution to challenge #2](#solution2)
    + [Solution to challenge #3](#solution3)
  * [Links](#links)
  * [License](#license)

## Playthrough

![tic _tac_toe_demo](https://user-images.githubusercontent.com/59072282/116927626-c0db8c00-ac10-11eb-835f-4ce5dcac4d81.gif)

## Design

### Flowchart
Since this project is fairly simple in terms of the gameplay and complexity, I decided to start things off by first creating a flowchart. 

![flowchart](https://user-images.githubusercontent.com/59072282/116512779-64c5e000-a87d-11eb-8c13-988e13949568.png)

Based on the flow chart, I broke down the tic tac toe game into classes. 
The *main classes* I identified were:

  - Board 
  - Players
  - Renderers
  - Input Handlers
  - Game State/Error Handlers

### Class Diagram
Here is a class diagram of the tic tac toe application:

![ClassDiagram1](https://user-images.githubusercontent.com/59072282/116908607-f6c04680-abf7-11eb-93c7-8d1abe103f86.png)

### Iteration: 
1. Get tic tac toe board to render on the console and be able to place a marker on a square. 
2. Be able to keep track of turns and alternate between 'X' and 'O'. Also, play against a simple AI that makes random moves based on a list of available (*empty*) squares. 
3. Implement the *minimax algorithm* and create an unbeatable AI. 

## Features

- [X] Play vs. Impossible AI
- [X] Console UI to play the game 
- [ ] Choose game mode: Human vs. Human, Human vs. AI, AI vs. AI
- [ ] Choose computer difficulty: Easy, Medium, Impossible 
- [ ] Scoreboard of wins, losses, ties
- [ ] Web application version 

## Challenges

Here are some of the notable challenges I faced while creating the tic tac toe application: 

1. Creating an **unbeatable AI** 
2. Writing **unit tests**
3. How to **check for a win**


## Solutions


### Solution to challenge #1 <a name="solution1"/>
The minimax algorithm was implemented to create an AI that is impossible to beat. The **minimax** is an algorithm that searches to a certain depth (DFS) of a game decision tree and then it begins assigning values to the nodes at that level, *i.e. **terminal nodes***. 

Then the algorithm *recursively* assigns values as it climbs back up to the root node. Once the search is complete, the minimax algorithm evaluates the best move for the current board position. 

Also, the levels of the game decision tree alternate between `X` and `O` making a move. As a result, when the algorithm is evaluating the best move for that particular turn, it will either try to *maximize* or *minimize* the value when considering all the possible board positions. 

Here is a diagram illustrating the game decision tree

![tic tac toe decision tree](https://user-images.githubusercontent.com/59072282/116911370-a77c1500-abfb-11eb-8502-996662eedd4c.png)

and then here is how the minimax algorithm works in finding the most *optimal* move

![game decision tree eval](https://user-images.githubusercontent.com/59072282/116963315-61579d80-ac5d-11eb-9043-3c13c606e1a9.png)


In other words, the AI is able to map out all future moves and determine which move will result in a tie or a win. Hence, the impossible AI will never make a *losing* move.

Based on the provided pseudocode shown below:

```
function minimax(node, depth, maximizingPlayer) is 
   if depth = 0 or node is a terminal node then
      return the heruistic value of node
   if maximizingPlayer then 
      value := negativeInfinity 
      for each child of node do 
        value := max(value, minimax(child, depth-1, FALSE))
      return value
    else (* minimizing player *)
      value := positiveInfinity 
      for each child of node do 
        value := min(value, minimax(child, depth-1, FALSE))
      return value
 ```


I implemented my own version of it: 

```
private double MiniMax(char[,] node, int depth, bool isMaximizer)
{
  // Base case 
  if (CheckTerminalNode(node))
  {
    var gameState = new GameState(node);
    if (gameState.EvaluateBoard() == 0)
      return 0;
    return gameState.EvaluateBoard();
  }

  if (isMaximizer)
  {
    double maxValue = double.NegativeInfinity;
    int index = 1;
    foreach (var child in node)
    {
      if (char.IsWhiteSpace(child))
      {
        var position = converter.ConvertSquareToPosition(index);
        node[position.Row, position.Column] = 'X';
        maxValue = Math.Max(maxValue, MiniMax(node, depth + 1, false));
        node[position.Row, position.Column] = ' ';
      }
      index++;
    }
    return maxValue;
  }
  else
  {
    double minValue = double.PositiveInfinity;
    int index = 1;
    foreach (var child in node)
    {
      if (char.IsWhiteSpace(child))
      {
        var position = converter.ConvertSquareToPosition(index);
        node[position.Row, position.Column] = 'O';
        minValue = Math.Min(minValue, MiniMax(node, depth + 1, true));
        node[position.Row, position.Column] = ' ';
      }
      index++;
    }
    return minValue;
  }
}
```

One issue I faced while implementing the algorithm was figuring out how to temporarily fill in an empty square with a marker, *e.g.`X` or `O`* and then revert the board back to its original state. I continued to have the original board mutate through each iteration of the `for` loop and consequently I was unable to go through all the possible board positions. Eventually, the solution I came up with was to find the `position` of the empty square and then assign a `X` or `O` to it and after calling the `minimax` change the square back to an empty space. 

### Solution to challenge #2 <a name="solution2"/>

When it came to writing unit tests I used xUnit, FluentAssertions, and Moq as my testing/mocking frameworks. I ran into issues when testing a particular method where it would invoke an instance method of an object that was instantiated inside of the method body. 

It looks something like this:

```
class A
{
    Foo()
    {
      B obj = new B();
      obj.Bar();
    }
}

class B
{
    Bar() {};
}
```

So when writing the test case for `Foo`

```
[Test Method]
public void Foo()_CheckValue
{
  A obj = new A();
  A.Foo();
}
```

I want to be able to mock the call to `Bar()`.

In order to do this, I followed the dependency inversion principle to have `B` implement an interface `IB` and have `A` depend on `IB` instead of `B`. 

```
class A
{
    private IB _ib;
    
    public classA(IB ib)
    {
      _ib=ib;
    }
    Foo()
    {
      _ib.Bar();
    }
}

public interface IB
{
  Bar();
}

class B: IB
{
    public Bar() {};
}
```

Now, using `Moq` I mocked `IB` and injected that mock to the constructor of `A` like so: 

```
[Test Method]
public void Foo()_CheckValue
{
  var bMock = new Mock<IB>();
  bMock.Setup(p => p.Bar());
  A obj = new A(bMock.Object);
}
```

### Solution to challenge #3 <a name="solution3"/>

When I was creating the `board` class I decided to have a `Position` object that would have a `row` and `column` property to represent the (x, y) coordinate system. 

![tic tac toe grid ](https://user-images.githubusercontent.com/59072282/116920367-64c03a00-ac07-11eb-8746-103c0a0e6d50.png)

My solution to checking for wins was to convert my 2D (`char[,]`) array into a 1D `char[]` array and check for *winning* lines or rows. 
The converted board is called a `LineBoard` and it would look something like this: `['0','1','2','3','4','5','6','7','8']`.

In the game of Tic Tac Toe, there are **3** ways of making a row that results in a win: horizontally, vertically, or diagonally. Now, based on the `LineBoard`, there are *eight* possible combinations.

Here are the winning combinations using the indices of the `LineBoard` to represent the *winning row*. 

**Horizontal Lines**
- [0,1,2]
- [3,4,5]
- [6,7,8]

**Vertical Lines**
- [0,3,6]
- [1,4,7]
- [2,5,8]

**Diagonal Lines**
- [0,4,8]
- [2,4,6]


Knowing that each winning line covers three squares I made a method called `IsThreeInARow` to check if all three squares had the same `mark` ('X' or 'O'). 

```
private bool IsThreeInARow(int i, int j, int k, char mark)
{

  if (char.IsWhiteSpace(mark))
  {
    return false;
  }
  else if (lineBoard.BoardState[i] == mark && lineBoard.BoardState[j] == mark && lineBoard.BoardState[k] == mark && !char.IsWhiteSpace(lineBoard.BoardState[i]))
  {
    this.mark = mark;
    return true;
  }
  return false;
}
```

I also had to consider cases when the board had a row of empty squares, in which case I returned `false` as this was not considered a win. 

*Also, as I'm writing this up I realize that I am repeating myself in the code above with the first `if` statement checking to see if the marker is a whitespace and then later checking to see that the `mark` is not a whitespace in the subsequent `else if` statement.* 

Next, I created a method called `CheckAnyLine`

```
private bool CheckAnyLine(int start, int increment)
{
  return IsThreeInARow(start, start + increment, start + increment + increment, lineBoard.BoardState[start]);
}
```
First off, I want to define what a **line** means in this context. Any line that is "drawn" on the **3x3 board** will span over three squares and thus can be interpreted as a composition of three points where two points are on the ends of the line and the last point is on the "center" of the line. 

Assuming this premise holds true, the distance between either of the endpoint to the center will be equal and can be labelled as an 'increment'. 
Here is an illustration of what the *line* would look like with its three points: 

![tic tac toe line ](https://user-images.githubusercontent.com/59072282/116920037-02ffd000-ac07-11eb-8241-fcf990dbfc92.png)

Hopefully, this explanation provides the reasoning as to why I created this method and why I am passing in `start`, `start + increment`, `start + increment + increment` as the arguments to `IsThreeInARow`. 

Referring back to how there are **three** different types of lines I will briefly explain the methods I created to handle each type of line. 
1. Horizontal Lines: 
```
private bool CheckHorizontal(int start)
{
  return CheckAnyLine(start, 1);
}
```
> [0,1,2]
>  
> [3,4,5]
> 
> [6,7,8]
> 

*To note: All 3 horizontal lines follow the formula of* 
**[x, x+1, x+2]**, 
*which is why I pass in an `increment` of **1** when calling `CheckAnyLine`.*

2. Vertical Lines: 
```
private bool CheckVertical(int start)
{
  return CheckAnyLine(start, 3);
}
```
> [0,3,6] 
> 
> [1,4,7]
> 
> [2,5,8]
> 

*To note: All 3 vertical lines follow the formula of*
**[x, x+3, x+6]**, 
*which is why I pass in an `increment` of **3** when calling `CheckAnyLine`.*

3. Diagonal Lines: 
> [0,4,8] **diagonal line**
> 
> [2,4,6] **anti-diagonal line**
> 

Interestingly, I did not have to write a method to handle the diagonal lines. 

For the *diagonal* line, I call `CheckAnyLine(0,4)` with a `start` of **0** and `increment` of **4**.

For the *anti-diagonal line*, I call `CheckAnyLine(2,2)` with a `start` of **2** and `increment` of **2**.

**Finally**, I have a `CheckWin` method that will call on all *eight* possible combinations, like so: 
```
public bool CheckWin()
{
  return CheckHorizontal(0) || CheckHorizontal(3) || CheckHorizontal(6) ||
      CheckVertical(0) || CheckVertical(1) || CheckVertical(2) ||
      CheckAnyLine(0, 4) || CheckAnyLine(2, 2);
}
```

## Links
- Demo: *Coming Soon*
- Repository: https://github.com/gosupark27/TicTacToe
- Trello: https://trello.com/b/wo2q91GS/tic-tac-toe

## License

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](/LICENSE)
