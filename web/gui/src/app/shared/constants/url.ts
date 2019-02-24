import { environment } from 'src/environments/environment';

export const url = {
	default: `/login`
};

export function baseUrl() {
	return environment.production
		? `http://localhost:5000/api/v1`
		: `http://localhost:5001/api/v1`;
}
