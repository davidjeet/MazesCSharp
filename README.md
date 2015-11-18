##Mazes For Programmers  (the C-Sharp Version)


###Algorthims
Not all algorithms in the book are covered here, but the majority are. At a basic level, these are covered:

* AldousBroder
* BinaryTree
* GrowingTree (the flexible algorithm that allows you to plug in selectors)
* HuntAndKill (95% working...still some weirdness)
* Kruskals
* RecursiveBacktracker
* RecursiveDivision (can be used to generate rooms)
* SideWinder
* SimplifiedPrim (precursor to TruePrim)
* TruePrim (precursor to GrowingTree) 

###Solution Layout
 There are two solution folders:
 * Infrastructure
 * Maze Demos
 
**Infrastructure** is responsible for the algorithms and supporting grid/cell objects.
**Maze Demos** are individual console C# projects responsible for executing each algorithm.


###Future
Some ideas going forward:
* Consolidate all of the Maze Demos to a single console application where the user selects the type of algorithm to run and the relevent parameters. 
* Implement IEnumerator for the grid.
* Consolidate the IGrowingTreeAlgorithms and IAlgorithms interfaces.
* Maybe refactor namespaces in Infrastructure to fewer.
* Work on a more robust/pretty console display method. 
* Work on a more non-console display method (Winforms? WPF?)

