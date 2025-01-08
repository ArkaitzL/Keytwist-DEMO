# Demo Técnica: Mecánicas de Juego

Este repositorio contiene una **demo técnica** que tiene como objetivo explorar y probar mecánicas específicas de juego. Estas demos no son proyectos completos ni juegos finales, sino ejemplos funcionales diseñados para experimentar con conceptos técnicos y de jugabilidad.

Cada demo está enfocada en una mecánica específica, con el objetivo de proporcionar un entorno simple y directo donde se pueda observar y probar su implementación.

---

## Demo: Twister para Teclado

Esta demo es un juego competitivo diseñado para que dos jugadores compartan un teclado y pongan a prueba su destreza y coordinación. Inspirado en el clásico juego **Twister**, los jugadores deben pulsar y mantener teclas específicas en el teclado. El primer jugador que suelte una tecla pierde la partida.

### Reglas del Juego
1. **Inicio del juego**: 
   - Cada jugador toma una posición en el teclado (izquierda y derecha).
   - Las teclas asignadas aparecerán de manera aleatoria en la pantalla.
   
2. **Objetivo**:
   - Mantén las teclas asignadas presionadas.
   - Si sueltas una tecla antes que tu oponente, ¡pierdes el juego!

3. **Dificultad progresiva**:
   - A medida que avanza el juego, se asignarán más teclas para mantener pulsadas, complicando los movimientos en el teclado.

### Controles
El juego asigna teclas de manera aleatoria en el teclado completo. Ambos jugadores deberán reaccionar rápidamente y coordinarse para pulsar las teclas indicadas. 

- **Jugador 1 (izquierda)**: Usará las teclas del lado izquierdo del teclado.
- **Jugador 2 (derecha)**: Usará las teclas del lado derecho del teclado.

### Características Principales
- Mecánica competitiva para dos jugadores en un solo teclado.
- Generación aleatoria de teclas para pulsar.
- Progresión en dificultad mediante la asignación de más teclas con el tiempo.
- Derrota automática al soltar una tecla requerida.
- Ideal para jugar con amigos en un entorno informal.

### Nota Importante
Ten en cuenta que algunos teclados tienen un límite en la cantidad de teclas que pueden detectarse al mismo tiempo (limitación conocida como "key rollover"). Esto puede afectar la experiencia de juego si se utilizan demasiadas teclas de manera simultánea. Se recomienda probar la demo con un teclado que admita "n-key rollover" (NKRO) si es posible.

### Cómo Ejecutar
1. Clona este repositorio en tu máquina local:
   ```bash
   git clone https://github.com/tuusuario/demo-twister-teclado.git
