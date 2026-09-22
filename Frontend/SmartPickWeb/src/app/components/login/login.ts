import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class LoginComponent {
  // Variables para guardar lo que se escribe en pantalla
  rut = '';
  password = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

iniciarSesion() {
    // 1. Verificar si el botón reacciona y si está leyendo las cajas de texto
    console.log('1. Botón presionado. RUT:', this.rut, ' Password:', this.password);

    if (!this.rut || !this.password) {
      alert('Por favor ingresa tu RUT y contraseña');
      return;
    }

    // 2. Verificar si intenta conectarse al backend
    console.log('2. Llamando a la API...');
    
    this.authService.login(this.rut, this.password).subscribe({
    next: (respuesta: any) => {
        // 3. Verificar si el backend respondió OK
        console.log('3. Respuesta del backend OK:', respuesta);
        
        localStorage.setItem('perfilId', respuesta.idPerfil.toString());
        
        if (respuesta.idPerfil === 1) {
          console.log('4. Redirigiendo a Admin...');
          this.router.navigate(['/admin']); 
        } else {
          console.log('4. Redirigiendo a Picker...');
          this.router.navigate(['/picker']); 
        }
      },
      error: (err: any) => {
        // 4. Verificar si hubo un error de credenciales o de red
        console.error('3. Error al contactar al backend:', err);
        alert('RUT o contraseña incorrectos');
      }
    });
  }
}