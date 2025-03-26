import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import { RouterProvider } from 'react-router-dom'
import { Router } from './Routes/Router.tsx'
import { createTheme, MantineProvider, useMantineTheme } from '@mantine/core'
const theme = createTheme({})
createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <MantineProvider theme={theme}>
            <RouterProvider router={Router} />
        </MantineProvider>
    </StrictMode>,
)
