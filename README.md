# advent-of-code-2022
```
Elves are moving
crates around me
coders playing
having fun

It's the season 
of riddles you solve with code
Merry Christmas Advent of Code
```

The annual fun has begun to solve the 24 riddles in the [Advent of Code](https://adventofcode.com/) challenge. 

In this repo I'll tackle the challenge in 3 stages:

1. solve the riddles with the first idea that comes to my mind
2. snapshot test the solutions with [Verify](https://github.com/VerifyTests/Verify)
3. find the most optimal solution and test it with [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)

Stage 2 and 3 will most likely only begin in 2023 since some riddles can take a surprising amount of time if you also create a generic input parser for the riddle input. And that's what I do so bear with me here.

#### Why do I want to tackle stages 2 and 3?

I haven't used Verify so far but I have seen it several times already and I figured it would be a great way to *verify* that the output of the solutions - which are already validated by the Advent of Code website - stays the same once it comes to the performance improvements. So stage 2 is basically me getting to know a new framework.

And stage 3 is simply: I like performant code. I do not have a lot of opportunities to write performance focused code professionally. So I want to do that in this private project here.

