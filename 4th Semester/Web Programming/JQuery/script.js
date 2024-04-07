$(document).ready(function () {
  $(".piece").click(function () {
    var emptyCell = $(".empty");
    var clickedCell = $(this);

    // Get the row and column of the clicked cell
    var clickedRow = parseInt(clickedCell.data("row"));
    var clickedCol = parseInt(clickedCell.data("col"));

    // Get the row and column of the empty cell
    var emptyRow = parseInt(emptyCell.data("row"));
    var emptyCol = parseInt(emptyCell.data("col"));

    // Check if the clicked cell is adjacent to the empty cell
    if (
      (Math.abs(clickedRow - emptyRow) === 1 && clickedCol === emptyCol) ||
      (Math.abs(clickedCol - emptyCol) === 1 && clickedRow === emptyRow)
    ) {
      // Swap the positions of the clicked cell and the empty cell
      emptyCell.text(clickedCell.text()).removeClass("empty");
      clickedCell.text("").addClass("empty");

      // Update data attributes
      emptyCell.data("row", clickedRow);
      emptyCell.data("col", clickedCol);
      clickedCell.data("row", emptyRow);
      clickedCell.data("col", emptyCol);
    }
  });
});
