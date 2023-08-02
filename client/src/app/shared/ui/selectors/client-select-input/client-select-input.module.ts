import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientSelectInputComponent } from './client-select-input.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CreateClientDialogModule } from 'src/app/features/clients/ui/create-client-dialog/create-client-dialog.module';

@NgModule({
  declarations: [ClientSelectInputComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatAutocompleteModule,
    MatTooltipModule,
    MatButtonModule,
    MatIconModule,
    CreateClientDialogModule
  ],
  exports: [ClientSelectInputComponent]
})
export class ClientSelectInputModule {}
