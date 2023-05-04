import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from 'src/app/Services/api.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-form-farmacia',
  templateUrl: './form-farmacia.component.html',
  styleUrls: ['./form-farmacia.component.css']
})
export class FormFarmaciaComponent {
  form: FormGroup = new FormGroup({
    nombre: new FormControl('', [Validators.required]),
    direccion: new FormControl('', [Validators.required]),
    telefono: new FormControl('', [Validators.required]),
    nit: new FormControl('', [Validators.required]),
  });

  constructor(private api: ApiService) { }

  submit() {
    let validationMessage: string;
    console.log(this.form.value)
    if (this.form.valid) {
      validationMessage = 'La validación fue correcta';
      this.api.Post('Farmaciums', this.form.value).then(() => {
        // Éxito en la llamada POST
        this.submitEM.emit();
      }, (error) => {
        // Error en la llamada POST
        this.error = error.message;
      });
    } else {
      validationMessage = 'Por favor, complete todos los campos';
    }

    validationMessage == "Validacion incorrecta" ? Swal.fire(
      'Error',
      'Validacion incorrecta',
      'error'
    ) : Swal.fire(
      'Succes',
      'Validacion Correcta',
      'success'
    )
  }

  @Input() error: string | null;
  @Output() submitEM = new EventEmitter();
}