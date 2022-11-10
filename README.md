# prototype farm

Implemented on Unity 2021.3

![image](https://user-images.githubusercontent.com/43387685/201119537-ab4550e7-b607-40a2-9072-3e766b143699.png)

This is a cell farm. In cells, you can plant different plants that grow. After maturation with plants, you can perform a certain set of actions.

## There is a basic interface:
* Main menu.
* Game menu.

## Level types:
* Pre-prepared depending on the GameSettings(ScriptableObject) settings.

![image](https://user-images.githubusercontent.com/43387685/201121154-36c0fc2e-efa3-48f8-a2e6-ba95e5311400.png)
![image](https://user-images.githubusercontent.com/43387685/201122812-9c85495b-b1a7-48d5-b0ae-a46e7af8e995.png)

## Mechanics:
* View from above.
* On the territory of the farm there is a playing field consisting of cells. A field with a customizable number of cells (width and length, generated when the game starts).
* You can plant in cages: trees, carrots and grass.
* The player taps on a free cell, a UI panel appears for selecting the type of plant (tree, carrot, grass) that the player wants to plant in this cell.
* After choosing the type of plant, the main character runs to the cage and plants the plant.
* A UI appears above the plant, showing the time until the plant “ripens”.
* Growth time for all types of plants is different.
* The camera flies up to the plant during planting and harvesting.
* After planting, the plant begins to grow, he can plant other plants.
* After the ripening time is over: carrots can be picked up, grass can be mowed and trees cannot be done with them.
* For each plant grown, the player is given experience. The longer the growth process, the more experience.
* The game screen displays the number of carrots and the amount of experience.

![image](https://user-images.githubusercontent.com/43387685/201121014-f63b8dd3-f2f1-4ebb-9477-e5c9fe349233.png)

## Links:
--
