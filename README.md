# Guess The Number game

## Architecture

The solution consists of a Web-API written with ASP.NET Core and a React front-end.

### Backend

The backend is written with ASP.NET Core and uses Controller-based APIs. The API exposes two methods: one for starting
a game with the specified difficulty level and another one for guessing the number of a running game. The client
identifies the game with a game Id that is sent back together with the number range of the selected difficulty level
as result of the start game request.

The ´result of the call for guessing the number returns the number and one of the three possible messages "too low",
"too high", and "correct".

### Frontend

The React frontend consists of one component that handles the communication with the backend and the game logic. It
uses the State hook to save the inputs and the game state:

* `difficulty`: Saves the currently selected difficulty level
* `game`: `null` when the game hasn't been started yet or the returned game object
* `nextGuess`: The value of the input field used for entering the number to guess
* `results`: An array with the results of the guesses of the game
* `gameResult`: The result object when the previous number has been guessed

When the number has been guessed that state is set back to the default values and a new game can be started.

## Design choices

In order to simplify the solution the backend does not store the game state in a database, but it is kept in memory.
Therefore the backend cannot be easily scaled and used with a load balancer.

The whole frontend code is implemented in a single React component. Maintainability would be improved by splitting the
code in smaller components.

Integration tests and unit tests for the backend can be found in the `GuessTheNumber.Tests` project.

## Possible improvements

* Use a proper database for storing the game state on the backend.
* Splitting the App component in smaller components.
* Possibley extracting the code for the communication with the backend.
* Deciding whether a game has been won on the backend.
