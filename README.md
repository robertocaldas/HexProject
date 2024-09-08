My objective was to create a system that can be extended to use other types of hex implementations or even different shapes (e.g. square grid) and board shapes (rectangular, honeycomb, etc.).

It is also prepared to easily add the ability to have more than two players and different types of players (AI, human).

Because of lack of time I couldn't implement some of the visual requirements like continuous movement, increase brightness to show attacks and other visual cues. However, the system provides a way to retrieve the data necessary to do so (see ICommand). You can check the log in the console to better understand what is happening.

I also added TODOs in the code of things that need to be considered or implemented.

Use Unity 2022.3.36f1, open the MainScene and press space to simulate one step.