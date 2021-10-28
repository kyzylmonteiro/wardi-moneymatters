# wardi-moneymatters
https://youtu.be/BL4cTxYsLb0

AddMoney.c
/Assets/a gets spawned when a 100 Rupee note is identified, which also carries around the "100" virtual object. The /Assets/a also has a collider which on colliding (OnCollisionEnter) with another /Assets/a spawns the "200" virtual object, and  on exiting collision (OnCollisionExit) deletes the object. The OnCollisionEnter and OnColliosnExit also handle the UI overlay change i.e. budget update. 
