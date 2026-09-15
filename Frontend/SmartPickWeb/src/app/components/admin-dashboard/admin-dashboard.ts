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

    alert("Acceso Denegado: Su perfil de Picker no tiene permisos de Administrador.");
    this.router.navigate(['/picker']);
  }

  cerrarSesion() {
    this.router.navigate(['/login']);
  }
}