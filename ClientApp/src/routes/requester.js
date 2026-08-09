export async function promptNilo(message) {
    const response = await fetch(
        `http://localhost:8080/chat?userData=${encodeURIComponent(message)}`,
        {
            method: "POST"
        }
    );

    if (!response.ok) {
        throw new Error(`Errore HTTP: ${response.status}`);
    }

    const answer = await response.text();

    return answer;
}