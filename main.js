//let timeInterval = undefined;
const hasWon = function(filledSudoku){
  return new SudokuChecker(filledSudoku).isUniq();
};

const setTime = function(time){
  timeInterval = setInterval(()=>{
    time+=1000;
    let cTime = new Date(time);
    showTime(cTime);
  },1000);
};

const setGameStatus = function(filledSudoku){
  if(hasWon(filledSudoku))
  showResult(winningStatus());
  else
  showResult(lossingStatus());
};

const gameResult = function(){
  let filledSudoku = getFilledBoard();
  setGameStatus(filledSudoku);
  clearInterval(timeInterval);
  getSolveId().style.visibility = setHidden();
  getBoard().disabled = true;
};

const startGame = function(){
  let filledPos = getFilledBoard();
  getBoard().onclick = ()=>{fillSudoku(filledPos)};
  getSolveId().onclick = gameResult;
};

const loadGame = function(){
  let time = 1483295400000;
  let mode = 'expert';
  let filledPos = [];
  let game = new Game();
  game.setLevel(mode)
  game.setBoard();
  let board = game.getBoard();
  drawBoard(board,filledPos);
  setTime(time);
  startGame();
};

window.onload = loadGame;