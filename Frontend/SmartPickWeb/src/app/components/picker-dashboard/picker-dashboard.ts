import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-picker-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './picker-dashboard.html',
  styleUrl: './picker-dashboard.css'
})
export class PickerDashboardComponent {
  
  articulos = [
    { id: 1, nombre: 'Arroz Grano Largo 1kg', sku: '987654321', ubicacion: 'Pasillo 4, Estante B', qty: 'x2', recolectado: false },
    { id: 2, nombre: 'Aceite Maravilla 1L', sku: '123456789', ubicacion: 'Pasillo 4, Estante C', qty: 'x1', recolectado: false },
    { id: 3, nombre: 'Salsa de Tomate 250g', sku: '456123789', ubicacion: 'Pasillo 5, Estante A', qty: 'x4', recolectado: false }
  ];

  constructor(private router: Router) {}

  marcarRecolectado(item: any) {
    item.recolectado = true;
  }

  todosListos(): boolean {
    return this.articulos.length > 0 && this.articulos.every(item => item.recolectado);
  }

  finalizarPedido() {
    alert('¡Orden finalizada con éxito! El pedido pasa a estado Completado.');
    this.articulos = []; // Limpia la lista en pantalla
  }

  cerrarSesion() {
    this.router.navigate(['/login']); 
  }
}