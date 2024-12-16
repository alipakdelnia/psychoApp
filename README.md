# PsychoApp

PsychoApp is an open-source platform designed for psychological analysis and self-improvement. Users can write daily journals, express their thoughts, and share their feelings. The app leverages AI (using OpenAI's GPT) to analyze users' inputs and provide psychological insights.

## Features

- **Daily Journals**: Users can write about anything, including their personal experiences, emotions, and interactions with others.
- **AI-Powered Analysis**: The backend sends user entries to ChatGPT for analysis and stores the insights in a database.
- **Admin Panel**: A web-based dashboard for admins to review user analyses and send notifications.
- **Personalized Insights**: Users receive notifications and insights based on their entries, like advice on handling relationships or understanding emotions.

## Technology Stack

### Backend
- Framework: **.NET Core 9**
- Database: **SQL Server**
- AI Integration: **OpenAI GPT API**

### Frontend
- **Admin Panel**: Developed with **Angular**

### Mobile App
- Platform: **Android**
- Language: **Kotlin**

### Design
- Prototype and UI: **Figma** (Optional)

## Project Structure

```
PsychoApp/
├── Backend/
│   ├── Controllers/
│   ├── Models/
│   ├── Services/
│   ├── Program.cs
│   └── appsettings.json
├── AdminPanel/
│   ├── src/
│   └── angular.json
├── MobileApp/
│   ├── app/
│   └── build.gradle
└── README.md
```

## Installation

### Prerequisites
- **.NET SDK 9**
- **Node.js** (for Angular Admin Panel)
- **SQL Server**
- **Android Studio** (for the mobile app)

### Backend
1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/psychoapp.git
    cd psychoapp/Backend
    ```
2. Install dependencies:
    ```bash
    dotnet restore
    ```
3. Run the project:
    ```bash
    dotnet run
    ```
4. Access the API at `http://localhost:5087`.

### Admin Panel
1. Navigate to the `AdminPanel` directory:
    ```bash
    cd psychoapp/AdminPanel
    ```
2. Install dependencies:
    ```bash
    npm install
    ```
3. Run the admin panel:
    ```bash
    ng serve
    ```
4. Access the admin panel at `http://localhost:4200`.

### Mobile App
1. Open the `MobileApp` folder in **Android Studio**.
2. Build and run the app on an emulator or physical device.

## Usage

1. Start the backend server and ensure it is running.
2. Launch the admin panel and log in as an admin.
3. Open the mobile app and log in as a user.
4. Write daily entries, and receive personalized insights after analysis.

## Contributing

Contributions are welcome! Here's how you can help:
- Report bugs and suggest features via [GitHub Issues](https://github.com/alipakdelnia/psychoapp/issues).
- Submit pull requests for improvements or bug fixes.
- Spread the word about the project.

### How to Contribute
1. Fork the repository.
2. Create a new branch:
    ```bash
    git checkout -b feature-name
    ```
3. Commit your changes:
    ```bash
    git commit -m "Add new feature"
    ```
4. Push to the branch:
    ```bash
    git push origin feature-name
    ```
5. Open a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any inquiries or support, please reach out to:
- **Email**: ali.pakdelnia77@gmail.com
- **GitHub**: [alipakdelnia](https://github.com/alipakdelnia)

---

We hope PsychoApp helps users achieve better self-understanding and emotional well-being!
