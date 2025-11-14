# Chain of Responsibility Pattern

Bir isteğin birden fazla handler (işleyici) tarafından sırayla işlenmesini sağlayan bir behavioral pattern’dir.
İstek zincir boyunca ilerler; her handler isteği işler veya bir sonrakine iletir.
Böylece isteği kimin işleyeceğine karar verme sorumluluğu client’tan alınır.