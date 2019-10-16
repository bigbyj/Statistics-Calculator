const SudokuSolver = function(board){
  this.board = board;
  this.emptyPositions = [];
};

SudokuSolver.prototype.getEmptyPosition = function(){
  this.board.forEach((row,rowIndex)=>{
    row.forEach((col,colIndex)=>{
      if(col==0)
      this.emptyPositions.push([rowIndex,colIndex])
    });
  });
};

SudokuSolver.prototype.checkRow = function(value,row){
  return this.board[row].every((ele)=>{
    return ele!=value;
  });
};

SudokuSolver.prototype.checkCol = function(value,col){
  return this.board.every((row)=>{
    return row[col]!=value;
  });
};

SudokuSolver.prototype.checkSquare = function(value,row,col){
  let rowIndex = 0;
  let colIndex = 0;
  let squareSize = 3;
  while (col>=colIndex+squareSize){
    colIndex += squareSize;
  }
  while (row>=rowIndex+squareSize){
    rowIndex += squareSize;
  }
  for (let i=rowIndex; i<rowIndex+squareSize; i++) {
    for (let j=colIndex; j<colIndex+squareSize; j++) {
      if(this.board[i][j]==value)
      return false;
    }
  }
  return true;
};

SudokuSolver.prototype.checkValue = function(value,row,col){
  return this.checkRow(value,row) && this.checkCol(value,col) && this.checkSquare(value,row,col);
};

SudokuSolver.prototype.solvePuzzle = function(){
  let limit = 9;
  for (let i=0; i<this.emptyPositions.length;) {
    let row = this.emptyPositions[i][0];
    let col = this.emptyPositions[i][1];
    let value = this.board[row][col]+1;
    let findValue = false
    while (!findValue && value<=limit){
      if(this.checkValue(value,row,col)){
        findValue = true;
        this.board[row][col]=value;
        i++;
      } else {
        value++;
      }
    }
    if(!findValue){
      this.board[row][col]=0;
      i--;
    }
  }
};

SudokuSolver.prototype.solveSudoku = function(){
  this.getEmptyPosition();
  this.solvePuzzle();
  return this.board;
};

// module.exports = SudokuSolver;