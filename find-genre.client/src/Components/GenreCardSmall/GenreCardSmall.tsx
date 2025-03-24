import { Card, Text } from "@mantine/core";
import styles from './GenreCardSmall.module.css'

function GenreCardSmall({ title, description }: { title: string, description: string }) {
    return (
        <Card shadow="md" className={styles.similar_card}>
            <Text size="xl" fw={500}>{title}</Text>
            <Text size="lg" lineClamp={4}>
                {description}
            </Text>
        </Card>
    );
}

export default GenreCardSmall;