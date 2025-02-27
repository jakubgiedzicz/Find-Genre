import { useEffect, useState } from "react";

function SearchByTag() {
    const [token, setToken] = useState();
    const [data, setData] = useState();
    useEffect(() => {
        const Login = async () => {
            const response = await fetch("https://localhost:7252/login", {
                method: "POST",
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    email: proccess.env.EMAIL,
                    password: process.env.PASSWORD,
                }),
            });
            const data = await response.json();
            setToken(await data.accessToken);
        };
        Login();
    }, []);
    useEffect(() => {
        if (token) {
            const Genres = async () => {
                const response = await fetch("https://localhost:7252/api/genre", {
                    method: "GET",
                    headers: { Authorization: `Bearer ${await token}` },
                });
                setData(await response.json());
            };
            Genres();
        }
    }, [token]);
    return <>{data.length}</>;
}

export default SearchByTag;
