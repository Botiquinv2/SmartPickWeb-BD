import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-picker-dashboard',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './picker-dashboard.html',
  styleUrl: './picker-dashboard.css'
})
export class PickerDashboardComponent implements OnInit {
  
  articulos: any[] = [];
  // Asegúrate de que este ID de pedido exista realmente en tu tabla de SQL Server
  pedidoId: number = 1; 

  constructor(private router: Router, private http: HttpClient) {}

  ngOnInit() {
    this.articulos = [
      { id: 1, nombre: 'Arroz Grano Largo 1kg', sku: '987654321', ubicacion: 'Pasillo 4, Estante B', qty: 'x2', recolectado: false },
      { id: 2, nombre: 'Aceite Maravilla 1L', sku: '123456789', ubicacion: 'Pasillo 4, Estante C', qty: 'x1', recolectado: false },
      { id: 3, nombre: 'Salsa de Tomate 250g', sku: '456123789', ubicacion: 'Pasillo 5, Estante A', qty: 'x4', recolectado: false }
    ];
  }

  marcarRecolectado(item: any) {
    // CP07: Cambia el estado visual en la pantalla
    item.recolectado = true;
  }

  todosListos(): boolean {
    return this.articulos.length > 0 && this.articulos.every(item => item.recolectado);
  }

finalizarPedido() {
    this.http.get(`http://localhost:5213/api/Pedidos/${this.pedidoId}`).subscribe({
      next: (pedido: any) => {
        
        // 1. Cambiamos solo el estado al valor numérico (2 = Completado)
        pedido.estado = 2; 
        
        // 2. NO borramos nada más. Le devolvemos a C# su propio objeto con todas 
        // sus propiedades de Navigation intactas para que el validador esté feliz.

        this.http.put(`http://localhost:5213/api/Pedidos/${this.pedidoId}`, pedido).subscribe({
          next: () => {
            alert('¡Orden finalizada con éxito! El pedido pasa a estado Completado en BD.');
            this.articulos = []; 
          },
          error: (err) => {
            console.error('Error al actualizar BD', err);
            alert('Error al contactar con la base de datos.');
          }
        });
      },
      error: (err) => console.error('Error al obtener el pedido', err)
    });
  }

  cerrarSesion() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}