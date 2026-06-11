# The Abandoned Hospital Heist

## Interactive 3D Experience (I3E) — Assignment 1

### Project Overview

**The Abandoned Hospital Heist** is a 3D first-person escape game developed in Unity. Players are trapped inside a dark and abandoned hospital ward and must navigate dangerous obstacles, avoid hazards, collect Staff Keycards, and unlock the final exit to escape.

The game focuses on exploration, platforming, environmental storytelling, and interaction systems within a single-level experience.

---

## Game Objective

Collect all **10 Staff Keycards** scattered throughout the hospital, survive the hazards, and unlock the final electronic security door to escape the facility.

---

## Controls

| Key        | Action                              |
| ---------- | ----------------------------------- |
| W, A, S, D | Move Player                         |
| Mouse      | Look Around                         |
| Space      | Jump                                |
| E          | Interact / Scan Keycard / Open Door |

---

## Features

### First-Person Controller

* Character Controller-based movement system
* Smooth mouse look controls
* Vertical camera rotation clamped to prevent flipping

### Environment & Platforming

* Abandoned hospital-themed environment
* Floating hospital beds as jump pads
* Mini maze with bed, minus hp.
* A pillow that travels user back and forward after all cards are collected

### Health & Hazard System

* Spoil beds deal 10 HP damage
* Automatic respawn system upon death

### Raycast Interaction System

* Interact with doors and keycards using raycasting
* Final security door only opens after collecting all keycards

### UI System

* Real-time score tracking
* Keycard collection counter
* Note prompts
* Game Start screen
* Game End screen

### Audio System

* Ambient horror background music
* Sound effects for:

  * Keycard collection
  * Damage taken

---

## Unity Setup

### Engine

* Unity 6

### Render Pipeline

* Universal Render Pipeline (URP)

### Components Used

* Character Controller
* Rigidbody
* Box Collider (Trigger)
* Audio Source
* TextMeshPro
* Canvas UI System

---

## How to Play

1. Explore the abandoned hospital.
2. Collect all 10 Staff Keycards.
3. Avoid hazards and dangerous gaps.
4. Reach the final security door.
5. Press **E** to interact.
6. Escape the hospital and win.

---

## GenAI Usage Disclosure

ChatGPT was used to:

* Review and debug scripts
* Improve code organization and comments
* Assist with implementation planning
* Generate development checklists
* Help troubleshoot gameplay systems

All game design decisions, implementation, testing, and final integration were completed by the developer.

---

## Credits

### Lecturer

* Guidance on UI Canvas systems and assignment requirements

### Learning Resources

* Lecture slides and tutorial videos
* Unity Documentation

### Developed By

**Cylina Ho**
Ngee Ann Polytechnic
Immersive Media
