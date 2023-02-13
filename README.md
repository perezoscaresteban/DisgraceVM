# DishonoredVM
Este es el proyecto principal de Oscar Esteban Perez de Coderhouse comision 32995

/*
GÉNERO
Acción-Aventura y Sigilo.
SINOPSIS Y PERSONAJE
Protagonista Vera Moray. Es una aristócrata de la alta sociedad en Dunwall. Como muchas
mujeres de allí fue obligada a casarse y a vivir su vida como esposa.
Cansada de la monotonía y de lo que se espera de ella, su vida cambia el día que llega con
su marido a unas misteriosas islas cerca de Serkonos, con motivo de unas vacaciones. Allí
descubrió que los pobladores adoraban a un dios, y tanto interés le causó que se hundió en
el estudio del mismo, descubriendo y siguiendo el camino de la magia negra.
La trama principal de la historia es la búsqueda del poder por parte de la
protagonista y escapar a su antiguo estilo de vida. A esto podemos sumarle la subtrama que
ocurre con el personaje The Outsider.
Worldbuilding
La historia se desarrolla en la ciudad de Dunwall. Más precisamente en la Mansion Moray
situada en la zona de aristócratas de la misma.
Dunwall, ciudad sede del poder imperial. Es una ciudad enorme y sombría situada en la isla
montañosa de Gristol.
Esta ciudad ficticia está basada en la ciudad de Londres de 1800.


MECÁNICAS
Clásicas de juegos de sigilo en primera persona.
- Ataque Melee.
- Objeto arrojadizo.
- Eliminación letal con sigilo por detras.
- Teleport.
- Poderes


IMPUTS (Hasta el momento)
- WASD -> Movimiento
- Barra espaciadora -> Salto
- Ctrl -> Agacharse / Sigilo
- Shift -> Correr
- F -> Acción (Esfera-prefab) aún no logré que pueda hacer daño al enemigo


SE IMPLEMENTÓ HASTA EL MOMENTO
-Movimiento del personaje. Movimientos horizontales en primera persona, salto y
agacharse.
-Camara en primera persona.
-1 estado del enemigo que persigue y te ataca. Tiene animación, y solo ataca cuando
se encuentra cerca. Si ataca reduce la vida del jugador.
-Instanciación de 1 poder del jugador. tiene un timer para desaparecer y otro para
evitar que se espamee (No logré aun que pueda hacer daño al enemigo que esté
dentro).
-Luces
-Todos los elementos son prefabs para luego poder pasar de una escena a la otra.
-Se implementó una barra de vida funcional.
-Colisiones con el jugador-suelo, enemigo-suelo, enemigo-jugador y enemigo-poder.
(Layers: Ground, Player, Enemy, Power)
*/
