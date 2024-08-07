import { useState } from 'react';
import './App.css';

interface Game {
    id: number;
    rangeMin: number;
    rangeMax: number;
}

interface Result {
    number: number;
    message: string;
}

function App() {
    const [difficulty, setDifficulty] = useState<string>("Medium");
    const [game, setGame] = useState<Game | null>(null);
    const [nextGuess, setNextGuess] = useState<string>("");
    const [results, setResults] = useState<Result[]>([]);
    const [gameResult, setGameResult] = useState<Result | undefined>(undefined);

    function startGame(difficultyLevel: string) {
        fetch('api/v1/games', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ difficulty_level: difficultyLevel })
        })
            .then(response => response.json())
            .then(game => {
                console.log(`Game: ${game.id}`);
                setGame(game);
            });
    }

    function guess(game: Game, number: number) {
        fetch(`api/v1/games/${game.id}`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ Number: number })
        })
            .then(response => response.json())
            .then(result => processResult(result));
    }

    function processResult(result: Result) {
        if (result.message !== "correct") {
            const newResults = Object.assign([], results);
            newResults.push(result);
            setResults(newResults);
        } else {
            setResults([]);
            setGame(null);
            setNextGuess("");
            setGameResult(result);
        }
    }

    function onStartGame() {
        startGame(difficulty);
    }

    function onGuess() {
        if (game === null) return;
        setNextGuess("");
        guess(game, parseInt(nextGuess));
    }

    return (
        <div>
            {game === null
                ? <div>
                    {gameResult && <p>The number {gameResult.number} was correct!</p>}
                    <label htmlFor="difficulty_level">Select difficulty:</label>
                    <select name="difficulty_level" id="difficulty_level" value={difficulty} onChange={e => {
                        setDifficulty(e.target.value);
                    }}>
                        <option value="Easy">Easy</option>
                        <option value="Medium">Medium</option>
                        <option value="Hard">Hard</option>
                    </select><br/>
                    <button autoFocus onClick={onStartGame}>
                        Start Game
                    </button>
                </div>
                : <div>
                    Enter a number in the range from {game?.rangeMin} to {game?.rangeMax}.<br/>
                    <label htmlFor="guess_input">Number:</label>
                    <input autoFocus type="number" tabIndex={0} value={nextGuess} onChange={e => setNextGuess(e.target.value)} onKeyDown={e => e.key == 'Enter' ? onGuess() : ''} />
                    <button onClick={onGuess}>
                        Guess
                    </button>
                    <ul>
                        {results.map(result =>
                            <li key={result.number}>The number {result.number} was {result.message}</li>)}
                    </ul>
                </div>}
        </div>
    );
}

export default App;