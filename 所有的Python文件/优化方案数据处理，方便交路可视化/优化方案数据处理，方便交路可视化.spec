# -*- mode: python -*-

block_cipher = None


a = Analysis(['C:\\Users\\����١���\\AppData\\Local\\Programs\\Python\\Python36\\Lib\\site-packages\\PyInstaller\\�Ż��������ݴ������㽻·���ӻ�\\�Ż��������ݴ������㽻·���ӻ�.py'],
             pathex=['C:\\Users\\����١���\\AppData\\Local\\Programs\\Python\\Python36\\Lib\\site-packages\\PyInstaller\\�Ż��������ݴ������㽻·���ӻ�'],
             binaries=[],
             datas=[],
             hiddenimports=[],
             hookspath=[],
             runtime_hooks=[],
             excludes=[],
             win_no_prefer_redirects=False,
             win_private_assemblies=False,
             cipher=block_cipher)
pyz = PYZ(a.pure, a.zipped_data,
             cipher=block_cipher)
exe = EXE(pyz,
          a.scripts,
          a.binaries,
          a.zipfiles,
          a.datas,
          name='�Ż��������ݴ������㽻·���ӻ�',
          debug=False,
          strip=False,
          upx=True,
          runtime_tmpdir=None,
          console=True )
