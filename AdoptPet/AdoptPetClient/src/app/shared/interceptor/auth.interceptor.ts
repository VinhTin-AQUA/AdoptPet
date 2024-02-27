import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { PetfinderService } from '../../services/petfinder.service';

export const authInterceptor: HttpInterceptorFn = (req, next) => {


	return next(req);
};
