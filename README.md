This is a project made in Unity. Made by TEAM14-ECSE211

# Introduction

This project is made for McGill Unversity ECSE211 course design principles and methods(DPM). Due to COVID-19, physical lectures and lab period are cancelled. Therefore, the initial lab part of the course is replaced with other materials. Under such constraint, this project was made.

# Rational

The purpose of this project is to simulate the course of actions that my team's robot would perform on the competition day. The simulation intents to accomplish a few goals which can be summarized as having a visual support to our documentations and showing that some physics and hardware components satisfy the constraints of our client. Note that you may/may not be find this useful if you are taking ECSE211 at another time.


# Advantage

- Given that the unity project is set up properly beforehand by TA's team, it can be a low cost test to run. A parallel can be drawn to cases where manufacturing companies of vehicles would test their prototype in virtual simulation. (DPM does not consider material and production cost the same way.)
- Test some code and logic when the physical model is not available. 
- Keep good social distances. Yeah... COVID-19 made us all think about this. To some extend, it is also useful without the presence of COVID-19?

# Disadvantage

- Difference of programming languages. Unity's main programming language is C#. DPM is in Java. The 2 languages are so similar that one can change codes from one to another easily. Though I did not use, i believe there are software programs for that. Unity is not the only software either. Another simulation environment in Java might also helpful.
- Inaccurate compared to physical tests. Some bias and false sense of security might occurred if the simulation result is positive. It doesn't mean the physical model will be working as well.
- Sensors and motors are not simulated(for the current version). This can be fixed by creating and introducing some noise making algorithms. I believe it's possible to create a really similar environment to real life. Of course, our team did not do that because of the cost and budget constraints.

# Some approaches explained
- To import 3d models, simply drap and drop .obj, .fbx, etc. files into the Unity asset folder. To have a more accurate simulation, make sure the 3d model files is composed of many meshes(each mesh is a lego block for example), so that when you add a collider to a piece, the whole physic remains accurate. (You don't want a collider box of the whole robot, but one for each part)
- For games, actions and logics and separated by frames. Effetively, if a function want to last more than one frame, it has to be of an IEnumerator and be called by the StartCoroutine() function. If not, then the function will return inside 1 frame, which means navigation will only last 1 frame. You can also use Thread, but I am uncertain of the possible conflicts with the Unity built-in system.
