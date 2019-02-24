import { environment } from 'src/environments/environment.prod';

export const url = {
	default: `/login`
};

export function baseUrl() {
	if (environment.production) {
		return `/api/v1`;
	}
	return `http://localhost:5000/api/v1`;
}
