import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [],
  templateUrl: './admin-dashboard.html',
  styleUrl: './admin-dashboard.css'
})
export class AdminDashboardComponent implements OnInit {
  
  constructor(private router: Router) {}

  ngOnInit() {
    // Leemos la memoria del navegador para ver quién entró
    const perfilId = localStorage.getItem('perfilId');

    // Si NO es Administrador (1), entonces sí lo expulsamos
    if (perfilId !== '1') {
      alert("Acceso Denegado: Su perfil de Picker no tiene permisos de Administrador.");
      this.router.navigate(['/picker']);
    }
  }

  cerrarSesion() {
    // Limpiamos la memoria al salir para poder cambiar de usuario tranquilamente
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}