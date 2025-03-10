import { useEffect, useState } from "react";
import { IGenre } from "../../Types/api";
import { Loader } from "@mantine/core";

function SearchByTag() {
    const [token, setToken] = useState<string | null>(null);
    const [data, setData] = useState<IGenre[]>();
    useEffect(() => {
        const Login = async () => {
            const response = await fetch("https://localhost:7252/login", {
                method: "POST",
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    email: import.meta.env.VITE_EMAIL,
                    password: import.meta.env.VITE_PASSWORD,
                }),
            });
            const data = await response.json();
            setToken(await data.accessToken);
        };
        if (!token) {
            Login();
        }
    }, []);
    useEffect(() => {
        const Genres = async () => {
            const response = await fetch("https://localhost:7252/api/genre", {
                method: "GET",
                headers: { Authorization: `Bearer ${await token}` },
            });
            setData(await response.json());
        };
        if (token) {
            Genres();
        }
    }, [token]);
    return (
        <>
            
        </>
    );
}

export default SearchByTag;
