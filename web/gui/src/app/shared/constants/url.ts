import { environment } from 'src/environments/environment';

export const url = {
	default: `/login`
};

export function apiBaseUrl() {
	return environment.production
		? `http://127.0.0.1:5000/api/v1`
		: `http://127.0.0.1:5001/api/v1`;
}
