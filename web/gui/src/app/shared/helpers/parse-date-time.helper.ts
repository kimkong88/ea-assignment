export function parseDateTimeToLocaleString(dateTimeString: any): string {
	const parseDateTime = new Date(Date.parse(dateTimeString));
	const options = {
		year: 'numeric',
		month: 'long',
		day: 'numeric'
	};
	return new Intl.DateTimeFormat('en-US', options).format(parseDateTime);
}
