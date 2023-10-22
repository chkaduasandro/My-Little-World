# My-Little-World

I started by creating a basic 2D URP Unity project. Initially, I only imported the DoTween package, as I knew it would be needed.

I began doing research on clothing and skinning variations, as the game is supposed to revolve around changing clothes. 
The best approach I found was to use a sprite library with sprite skins. However, more research is needed to determine if 
sprite skins only work on rigged sprites.

If we want to have four directions with skeletal animations, we would need
four different objects and animations. Another option, which seems a bit outdated, is sprite sheet swapping. 
I'll continue looking into this.

After completing my research, I decided on how to proceed with the project. Unfortunately, I wasted a lot of 
time searching for assets similar to those in "Little Sim World." Since pixel art wasn't as visually appealing,
I tried to find that specific art style. Realizing that I had wasted too much time, I refocused on core mechanics.

First, I finished the basics of the character controller. The recommended package already had an animator,
so I didn't spend too much time on animations, just made some minor adjustments.

Next, I focused my attention on the inventory system. After creating the logical side and a simple UI, the 
idea of creating a right-click context menu interaction came to mind. I knew this system would take a lot of time, but I felt it was necessary.

I eventually completed the right mouse click context menu controllers. There were many instances where I 
should have used a better hierarchy, but I had little time to think about my next steps. There are some duplicate code fragments that I tried to avoid at the beginning.

I initially thought the recommended asset already contained rigged sprites, but it turned out to be just 
a prefab with a bone rig. Combining all character sprite fragments, rigging the sprite, setting weights,
and splitting them into layers using software like Photoshop would take a lot of time. So, I had to improvise, and the solution was to create our own skinning system.

For now, I will refactor everything and focus on the main goals. I don't have time to finish everything 
at the moment, so I'll try to concentrate on the essentials.

I'm currently focusing on the in-game shop. It's not perfect, and there's a lot of messy code that needs
to be implemented, but there's no escaping that. I understand that creating the ideal game isn't possible in just two days, so I'll aim to complete it quickly instead of aiming for perfection.

Visualy I am not pleased. May be I focused too much on right assets at the begining and wasted too much time.




