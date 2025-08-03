# MiniProject
Data Structures and Algorithms ISCG6426
Student ID: 1509445 

DATA STRUCTURE /ALGORITHM 
For this assignment Trees were chosen and particularly Depth-first search (preorder , postorder and inorder) to create an interactive game/visualisations using its functionality/working principles.  I have programmed an educational game to learn the fundamentals of the different BST traversal orders.

Binary search trees (BSTs) were established by mathematician Arthur Cayley in 1857 as a data structure for expressing hierarchical relationships. BSTs have effective search, insertion, and deletion capabilities which has made them a fundamental component of computer science. BSTs are essential to many algorithms and are frequently given credit for serving as the model for more complex structures like red-black trees and AVL.

A tree is made up of a limited number of nodes, or elements, and branches, or directed lines or edges, that join the nodes. The root is the first node and there can be zero, one, or many successors for any node in the tree.  A binary tree traverse allows the processing of each tree node just once. Searching deeply into a branch and waiting to go to the next one until you've reached the end is known as "depth-first traversal." There are 3 types of traversals. Inorder (which goes left, root, right), postorder (which goes root, left, right) , preorder (which goes left, right then root).

STRENGTHS AND WEAKNESSES
Time Complexity
In the best case time complexity would be O(1) meaning that the node is found in  the first traversed node. In the worst case the time complexity would be O(n) with “n” being the depth of the tree. This would occur if the tree was unbalanced or was skewed
Space Complexity
The space complexity of a BST is O(n), with “n” being the depth of the tree  number of nodes present in a tree.


REAL-WORLD EXAMPLE
File systems
BST’s can be used for efficient accesses of files and their subdirectories.
Leader Boards
BST’s can be used for the leaderBoard in game so the highest score is at the top for easy retrieval.
Databases
BST’s are used to store sorted data for databases for quick searching, insertions, and deletions.

IMPLEMENTATION
I have created the game “Fruit Fall” to represent my chosen data structure/algorithm in an educational manner.

In Fruit Fall there are three game options for the user to select from:
Inorder 
In this version up to fifteen apples which represent nodes are in the shape of a  binary tree that is randomly generated and are displayed on a tree.
Preorder
In this version up to fifteen oranges which represent nodes are in the shape of a  binary tree that is randomly generated and are displayed on a tree.
Postorder.
In this version up to fifteen lemons which represent nodes are in the shape of a binary tree that is randomly generated and are displayed on a tree.

How it is played:
The user clicks on a fruit to make it fall off the tree. They should do it using their chosen game options traversal order. If they select the wrong fruit, the fruit they were supposed to choose changes into a “bad fruit” and they must continue to the next fruit in the traversal. If the fruit they selected was the correct fruit, the fruit will fall off the tree and the user can use the basket to catch the fruit. If they catch the fruit the user gets 10 points. If the fruit falls beyond the game window there are no points given.

The basket can be moved via the mouse. If the mouse is outside the screen left and right keyboards keys can be used.

To represent this data structure visually in my game I had to create a binary tree out of fruit:

***IMAGE AVAILABLE ON PDF***

To represent this data structure traversals visually in my game I had to create an array of each traversal type which would represent the traversal path of a fifteen node binary tree, then I had to make a custom traversal path that was randomly generated based on the initial traversal array:

***IMAGE AVAILABLE ON PDF***

This traversal path array is initialised when the user selects their game option.


This traversal path array is used to check the users selected fruit:

***IMAGE AVAILABLE ON PDF***

Classes that were made to create this game are MainWindow, PlayWindow, ManageFruitsPlayMode, BinaryTree, splashScreens, Fruit, Basket, Fruit and Sign.

The fruits that can be on the tree are limited by the size of the tree, so fifteen is the max amount. Initially my game was limited to 15  nodes only at a time but I had to acknowledge that not all binary trees are perfect/complete and I was failing to randomly generate the data. To fix this problem I created the BinaryTree class with methods to generate an array that would allow me to do so and new traversal methods along with it. Create fruit based on that array. This game serves as an educational game to learn the fundamentals of the different BST traversal orders so a complete binary tree is used,  also it makes the shape of the binary tree more obvious for the user.  I have attached the first version of this under the first version folder as it may be more usable for individuals learning the binary tree as the tree is complete and therefore easy due visualise reasons. On that version there are two different modes, in that version 
the fruit falls from the tree at regular time intervals in the user's chosen game option traversal order. The user must move the basket to catch the falling fruit.  If they catch the fruit the user gets 10 points. If the fruit falls beyond the game window there are no points given.


In the future using an actual binary tree would be an interesting concept, this would require a great deal of time as I did initially explore this option but found difficulty in placing the fruit on the tree in a binary shape.
