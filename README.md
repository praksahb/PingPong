# PingPong
 2- player ping pong 2d

implemented GameManager(singleton) for calling all important functions(game logic and ui). All except text controller for displaying countdown timer before ball starts moving.

implemented a coroutine inside a boolean flag(for running once) - function performed is to wait for countdown time before ball is moved.

collider Controller contains collision detection between (player-boundary lines) and (ball-boundary lines)

player Move Script for handling movement logic
